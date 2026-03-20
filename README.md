dnSpy.Extension.HoLLy
=====================

A [dnSpyEx](https://github.com/dnSpyEx/dnSpy) extension to aid reversing of obfuscated assemblies.

### Features
- **Change the displayed symbol name of types, methods, properties or fields, without modifying the binary.** These modified names are saved in an xml file, meaning you can write a tool to generate them automatically.
	- Please keep in mind that this works in a relatively hacky way, and it can't be seen as a perfect replacement for manually renaming symbols. See [current issues](https://github.com/HoLLy-HaCKeR/dnSpy.Extension.HoLLy/labels/area%3Asourcemap) for limitations.
	- This can be accessed through the decompiler language dropdown in the menu bar.
- **Inject managed (.NET) DLLs into the debugged process.** The injected DLL must have a method with signature `static int Method(string argument)`. .NET Core and Unity x64 are not yet supported.
- **Disassemble native functions**
- **Show control flow graphs for both managed and native functions**
- Underline managed assemblies in the treeview.
- Several commands to help with extension development in debug mode

### Other extensions
I have developed some other extensions which are linked here for convenience:
- [dnSpy.Extension.DiscordRPC](https://github.com/HoLLy-HaCKeR/dnSpy.Extension.DiscordRPC/tree/master)
- [dnSpy.Extension.ThemeHotReload](https://github.com/HoLLy-HaCKeR/dnSpy.Extension.ThemeHotReload/tree/master)

### Installation
Download the [latest release](https://github.com/holly-hacker/dnspy.extension.holly/releases/latest) for your dnSpyEx version (`net48` or `net10.0-windows`) and extract it to the `bin/Extensions/dnSpy.Extension.HoLLy` directory. You may need to create this folder.

If you build the extension yourself, use one of these output folders:

- `dnSpy.Extension.HoLLy/bin/Release/net48`
- `dnSpy.Extension.HoLLy/bin/Release/net10.0-windows`

Copy the full contents of the matching folder into `bin/Extensions/dnSpy.Extension.HoLLy/`. Do not copy only `dnSpy.Extension.HoLLy.x.dll`; the dependency DLLs are required too.

Your directory structure will look something like this:

```
dnSpy-net-win64/
|- dnSpy.exe
|- dnSpy.Console.exe
`- bin/
   |- Extensions/
   |  `- dnSpy.Extension.HoLLy/
   |     |- AutomaticGraphLayout.dll
   |     |- dnSpy.Extension.HoLLy.x.dll
   |     |- dnSpy.Extension.HoLLy.EchoPlatforms.dll
   |     |- Echo.dll
   |     |- Echo.ControlFlow.dll
   |     |- Echo.DataFlow.dll
   |     `- ...
   |- LicenseInfo/
   |- FileLists/
   |- Themes/
   |- dnSpy.Analyzer.x.dll
   |- dnSpy.Contracts.Debugger.dll
   `- ...
```

Also make sure that you are using the correct version of dnSpy that matches the plugin! This should be mentioned in the [release notes](https://github.com/holly-hacker/dnspy.extension.holly/releases/latest) or the [changelog](https://github.com/HoLLy-HaCKeR/dnSpy.Extension.HoLLy/blob/master/CHANGELOG.md).
The plugin **will not work** with certain mismatched versions due to strong-name signing of some dependencies.

### Usage
- **SourceMap decompiler**: select a decompiler variant ending in `(w/ SourceMap)` from the decompiler dropdown in the menu bar.
- **Rename displayed symbols**: while using a SourceMap decompiler, right-click a type, method, property or field and choose `Change displayed name`.
- **SourceMap menu**: use the top-level `SourceMap` menu for `Save SourceMap`, `Load SourceMap`, `Open SourceMap Cache Folder`, and `Open settings...`.
- **Create control flow graphs**: right-click a method and choose `Create CFG`.
- **Disassemble native methods**: right-click a native method and choose `Disassemble`.
- **Disassemble a native entrypoint**: right-click an assembly node and choose `Disassemble Entrypoint`.
- **Inject a managed DLL**: start debugging, then open the `Debug` menu and choose `Inject .NET DLL`.

For DLL injection, the target assembly must contain a method with signature:

```csharp
static int Method(string argument)
```

### Developing
To test the extension without copying files into the dnSpy installation, launch dnSpy with the `--extension-directory {directory}` argument, where `{directory}` is the build directory.

Examples:

```powershell
dnSpy.exe --extension-directory "D:\path\to\dnSpy.Extension.HoLLy\dnSpy.Extension.HoLLy\bin\Debug\net10.0-windows"
dnSpy.exe --extension-directory "D:\path\to\dnSpy.Extension.HoLLy\dnSpy.Extension.HoLLy\bin\Debug\net48"
```

JetBrains Rider supports launch profiles, allowing you to specify dnSpy as the executable to start. This means you can launch and debug the extension from within the IDE.

When using `--extension-directory`, prefer the modern .NET dnSpy build. .NET Framework assembly resolving can be more fragile when loading extensions from an external directory.

### License
Due to dnSpy being licensed under the GPLv3 license, this plugin is too.

### Used libraries
- [dnSpyEx](https://github.com/dnSpyEx/dnSpy) and its [dependencies](https://github.com/dnSpyEx/dnSpy#list-of-other-open-source-libraries-used-by-dnspy), licensed under the [GPLv3 license](https://github.com/dnSpyEx/dnSpy/blob/master/dnSpy/dnSpy/LicenseInfo/LICENSE.txt) and [others](https://github.com/dnSpyEx/dnSpy/tree/master/dnSpy/dnSpy/LicenseInfo)
- [iced](https://github.com/0xd4d/iced), licensed under the [MIT license](https://github.com/0xd4d/iced/blob/master/LICENSE.txt)
- [dnlib](https://github.com/0xd4d/dnlib), licensed under the [MIT license](https://github.com/0xd4d/dnlib/blob/master/LICENSE.txt)
- [Echo](https://github.com/Washi1337/Echo), licensed under the [LGPLv3 license](https://github.com/Washi1337/Echo/blob/master/LICENSE.md)
- [Microsoft Automatic Graph Layout](https://github.com/microsoft/automatic-graph-layout), licensed under the [MIT license](https://github.com/microsoft/automatic-graph-layout/blob/master/LICENSE)
