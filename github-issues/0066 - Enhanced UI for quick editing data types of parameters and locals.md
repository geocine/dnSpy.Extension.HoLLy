# Issue #66: Enhanced UI for quick editing data types of parameters and locals

- State: open
- Author: Washi1337
- Created: 2021-02-21 20:43:34 +00:00
- Updated: 2021-02-23 20:07:57 +00:00
- Labels: enhancement, minor-feature
- Comments: 0
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/66

## Body

## Summary
dnSpy is nice for simple quick patches in CIL, but currently lacks good UX for editing data types of locals and parameters inside a method. I would love to see something similar to tools like IDA/Ghidra, where you can quickly change the type of such a symbol without going deep into the edit dialogs. Here are a couple of proposals that you can consider including in your extension :)

## Relevant locations

Current method editing dialog is pretty inconvenient when it comes to changing the type of a single parameter. This is especially the case for methods with multiple parameters. There is also no edit button for a single parameter type:

<details>

![01](https://user-images.githubusercontent.com/3613449/108637398-b66f7a00-748a-11eb-8ae4-19785a6a920e.png)

</details>

Maybe add it here? Bonus points if it has a hotkey.
<details>

![02](https://user-images.githubusercontent.com/3613449/108637435-ef0f5380-748a-11eb-9258-7c5bf33e8daf.png)

</details>

In a similar fashion, it would be nice if we could retype local variables using a hotkey or context menu item (or both :P)

## Proposal for a re-type dialog box

Finding a new type to assign to the symbol is very clumsy at the moment in dnSpy. Would be pretty nice if you could just open a small dialog box and type in the C# type reference (with support for compound types like array or pointer specifiers). We could maybe use Roslyn that dnSpy is already referencing for the initial parsing. In case of ambiguity, there could be a dropdown with the choices, similar to how Ghidra does this

<details>

![03](https://user-images.githubusercontent.com/3613449/108638047-9db49380-748d-11eb-8ba4-80d4c71de2ff.gif)

</details>

