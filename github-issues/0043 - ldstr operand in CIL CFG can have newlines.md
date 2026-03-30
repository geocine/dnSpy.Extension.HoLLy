# Issue #43: ldstr operand in CIL CFG can have newlines

- State: closed
- Author: holly-hacker
- Created: 2020-10-20 08:40:01 +00:00
- Updated: 2020-10-20 15:14:05 +00:00
- Closed: 2020-10-20 15:14:05 +00:00
- Labels: enhancement
- Comments: 0
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/43

## Body

Expected behavior:
```
ldstr "\nSomething"
```

Actual behavior:
```
ldstr "
Something"
```

Example of actual behavior:
![example](https://i.imgur.com/wFjGdYU.png)

