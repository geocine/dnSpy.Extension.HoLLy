# Issue #35: Disassemble Tab title doesn't line up with the method name

- State: closed
- Author: ElektroKill
- Created: 2020-07-26 16:34:03 +00:00
- Updated: 2020-08-19 17:44:30 +00:00
- Closed: 2020-08-10 11:18:57 +00:00
- Labels: bug
- Comments: 1
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/35

## Body

Hello,

This issue happens when the method.Name property is empty. This makes dnSpy show the method name as <<EMPTY_NAME>>. However, on the disassembly tab, the name is just empty.

![image](https://user-images.githubusercontent.com/37494960/88484398-8b618e00-cf6e-11ea-88b7-77067200d131.png)

## Comments

### ElektroKill on 2020-08-10 07:16:05 +00:00

Hello, I saw your changes and I would like to point out that this is not entirely fixed. If I take a look at ConfuserEx Unicode renamer dnSpy escapes those names and here they are not escaped. I think it would be better to use dnSpy IdentifierEscaper class.

