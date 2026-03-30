# Issue #55: Feature Idea: Ability to edit the instructions of a x86 methods in managed assemblies.

- State: open
- Author: ElektroKill
- Created: 2020-12-15 14:13:36 +00:00
- Updated: 2020-12-15 14:19:55 +00:00
- Labels: enhancement
- Comments: 1
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/55

## Body

The title explains it all, it would be very cool if it's possible to implement.

Thanks in advance!

## Comments

### holly-hacker on 2020-12-15 14:19:10 +00:00

May be a bit tricky, since other x86 code could jump in the middle of the "function" you're trying to edit (x86 functions aren't as clearly defined, you just have a start RVA and need to figure out the rest yourself). Should be doable to allow the user to overwrite the code with other code that is of lower or equal length.

