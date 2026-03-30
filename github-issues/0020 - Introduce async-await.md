# Issue #20: Introduce async/await

- State: open
- Author: holly-hacker
- Created: 2019-07-18 18:57:47 +00:00
- Updated: 2019-07-22 13:46:28 +00:00
- Labels: enhancement, code quality
- Comments: 2
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/20

## Body

Most code runs on the UI thread and is thus blocking. That includes DLL Injection, which is bad because it can take a while.

This also prevents embarrassing issues such as 0xd4d/dnSpy#1212.

## Comments

### holly-hacker on 2019-07-18 18:58:21 +00:00

Planning on implementing this on the unity-dll-injection branch.

### holly-hacker on 2019-07-22 13:46:12 +00:00

Not needed yet and pretty invasive, I'll do this later when we're actually trying to perform work on the UI thread.

