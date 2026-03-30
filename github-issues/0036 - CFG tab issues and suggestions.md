# Issue #36: CFG tab issues and suggestions

- State: closed
- Author: ElektroKill
- Created: 2020-07-26 18:52:14 +00:00
- Updated: 2020-08-10 11:18:58 +00:00
- Closed: 2020-08-10 11:18:58 +00:00
- Labels: enhancement
- Comments: 2
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/36

## Body

Hello, I have some issues and suggestions regarding it.

- [x] Parts of the graph render outside of the tab control: ![image](https://user-images.githubusercontent.com/37494960/88486924-780bee00-cf81-11ea-82dc-1dac70aece7b.png)
- [x] Respect dark mode.
- [x] Make the title state the method name that the CFG belongs too.
- [x] Add an option to use the user's selected font for the CFG node text.
- [ ] Add the CFG option to the context menu of a method body and not just the method.

Thanks in advance.

## Comments

### holly-hacker on 2020-08-09 20:33:00 +00:00

CFG is still a work in progress, it is not in a released build.

Regardless:
- ~~Rendering outside the tab control doesn't really seem like an issue, and it'll require a bunch of WPF debugging.~~ not noticeable when using theme colors
- ~~Using user selected font may not be possible using the graph rendering lib~~
- Adding CFG option to context menu is likely not possible, since the only context we can get is about the selected item. Use a debug build and select the first item in the context menu to check for yourself.

As for the others, I'm still working on it so they're likely to be implemented in the future.

### holly-hacker on 2020-08-09 20:38:52 +00:00

Will keep open to track the features, I guess

