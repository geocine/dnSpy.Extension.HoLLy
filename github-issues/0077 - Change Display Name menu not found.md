# Issue #77: Change Display Name menu not found

- State: closed
- Author: chinasmu
- Created: 2023-03-24 02:08:08 +00:00
- Updated: 2023-08-01 16:37:14 +00:00
- Closed: 2023-03-24 11:26:19 +00:00
- Comments: 5
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/77

## Body

I use dnspy6.3
Found the menu SourceMap and it's submenus.
Also found Create CFG, and works fine.
But I cannot find the Change Display Name menu or like this,i do not kown it's accurate name.

## Comments

### holly-hacker on 2023-03-24 11:26:19 +00:00

You should change the decompiler to the sourcemap version and then rightclick a symbol name (such as a method) in the decompiler view. The option should appear there.

### Danon5 on 2023-08-01 01:42:22 +00:00

> You should change the decompiler to the sourcemap version

What does this mean? Where and how do you do this, and why is this information not provided anywhere else? Right-clicking a symbol does not reveal any relevant option on a fresh install of dnSpy and a fresh install of the extension.

Here is the context menu when right clicking a method in the "decompiler view":
![image](https://github.com/holly-hacker/dnSpy.Extension.HoLLy/assets/57692042/d20acca9-d291-4a0e-935c-941626741420)

### holly-hacker on 2023-08-01 11:19:54 +00:00

The decompiler is changed by the dropdown that should say "C#". You should change it to "C# (with sourcemap)".

### Danon5 on 2023-08-01 13:48:17 +00:00

Thank you. I don't believe this information is available in the readme. It may be obvious to people who are familiar with dnSpy, butÔÇöas someone who is new to it, I had no idea how to resolve this issue until asking you directly. If it's not in the readme, maybe it should be there.

### holly-hacker on 2023-08-01 16:37:14 +00:00

Updated with ea52dc43b4511e948b210af1bf0a466d13407115.

