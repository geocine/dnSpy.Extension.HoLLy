# Issue #42: Exception handlers can be shown more clearly in CFG

- State: open
- Author: holly-hacker
- Created: 2020-09-28 17:27:35 +00:00
- Updated: 2020-10-19 20:38:25 +00:00
- Labels: enhancement
- Comments: 2
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/42

## Body

Some possible improvements to make:
- Have everything inside a try block as its own BasicBlock, so it can jump out to the exception handler.
- Use clusters to group everything inside an exception handler try block

## Comments

### holly-hacker on 2020-09-28 17:30:26 +00:00

Should be respresentable using clusters (sub graphs with borders), as it is within Echo's dot writer

![washi image](https://i.imgur.com/ueI2FLN.png)

### holly-hacker on 2020-10-19 19:59:28 +00:00

Partially fixed so removing from v0.5.0 milestone. Issue now tracks improvements to how exception handlers are displayed.

