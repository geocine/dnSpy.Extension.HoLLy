# Issue #6: Apply sourcemaps to tooltips and treeview items.

- State: open
- Author: holly-hacker
- Created: 2019-07-07 01:15:42 +00:00
- Updated: 2020-07-24 15:10:18 +00:00
- Labels: enhancement, help wanted, area:sourcemap
- Comments: 0
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/6

## Body

Right now, decorators are used on the decompilers to change symbol names before they are written to the decompiler output. During this we get the actual dnlib types, allowing us to store full information about the member in the sourcemap (eg. namespace+type+method name+parameters).

With output to tooltips and tree node items, only a string and color is given. The string will only be the member name, without additional type or namespace. For matching in the sourcemap, we have the following options:
1. Try to match on the limited info anyway, but risking getting a false positive. Color can be used to find the type of the map (MethodDef, TypeDef, etc).
2. Make a decorator for each type that inherits from IMemberRef. This is a lot harder because a lot of functionality needs to be reimplemented, and we're writing decorators for classes, not interfaces. The Decompiler *will* use more than just the Name property of the IMemberRef, and match on its type.

