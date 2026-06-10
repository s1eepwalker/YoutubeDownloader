// Build-time helper that strips the "Deorcify" region-restriction check injected
// by the Deorcify package into third-party assemblies (e.g. YoutubeExplode).
//
// The check is a module initializer (Deorcify.Initializer.Execute) that aborts the
// process when the system region resolves to certain countries. This tool neutralizes
// every method body in that type, which disables the check and also drops the embedded
// string literals it relied on. The public API of the target assembly is untouched.

using Mono.Cecil;
using Mono.Cecil.Cil;

if (args.Length < 1)
{
    Console.Error.WriteLine("Usage: Deorcifier <assembly-path>");
    return 1;
}

var path = args[0];
if (!File.Exists(path))
{
    Console.Error.WriteLine($"Deorcifier: assembly not found: {path}");
    return 1;
}

using var assembly = AssemblyDefinition.ReadAssembly(
    path,
    new ReaderParameters { ReadWrite = true }
);

var initializer = assembly.MainModule.GetType("Deorcify.Initializer");
if (initializer is null)
{
    // Nothing to patch (clean assembly or different version) — succeed quietly.
    Console.WriteLine($"Deorcifier: no Deorcify.Initializer in {Path.GetFileName(path)}, skipping.");
    return 0;
}

var patched = 0;
foreach (var method in initializer.Methods)
{
    if (!method.HasBody)
        continue;

    method.Body = new MethodBody(method);
    var il = method.Body.GetILProcessor();

    // Return a harmless default for the method's return type.
    if (method.ReturnType.MetadataType != MetadataType.Void)
    {
        if (method.ReturnType.IsValueType)
            il.Append(il.Create(OpCodes.Ldc_I4_0));
        else
            il.Append(il.Create(OpCodes.Ldnull));
    }

    il.Append(il.Create(OpCodes.Ret));
    patched++;
}

assembly.Write();
Console.WriteLine(
    $"Deorcifier: neutralized {patched} method(s) in Deorcify.Initializer of {Path.GetFileName(path)}."
);
return 0;
