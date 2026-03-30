# Issue #4: Show recently injected DLLs in app menu

- State: closed
- Author: holly-hacker
- Created: 2019-07-07 00:43:19 +00:00
- Updated: 2019-07-08 22:49:35 +00:00
- Closed: 2019-07-08 22:49:35 +00:00
- Labels: enhancement
- Comments: 0
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/4

## Body

Prevents user from having to select a file and entry point when repeatedly injecting the same DLL. A new menu item will exist under the "Inject .NET DLL" which will open to show up to 5 recent injected DLLs, along with entrypoint and parameter. If there are no recent items, the menu is disabled but not hidden.

Items will be displayed as `DllName.dll TypeName.Method("argument")`. Optionally, when multiple items have the same name but different meaning (eg. 2 different DLLs named InjectMe.dll), the display may be more specific.

Will require settings implementation.

