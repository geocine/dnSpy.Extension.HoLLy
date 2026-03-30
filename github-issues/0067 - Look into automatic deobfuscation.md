# Issue #67: Look into automatic deobfuscation

- State: open
- Author: holly-hacker
- Created: 2021-02-22 21:17:05 +00:00
- Updated: 2021-02-22 21:17:05 +00:00
- Labels: enhancement, needs research, major-feature
- Comments: 0
- URL: https://github.com/holly-hacker/dnSpy.Extension.HoLLy/issues/67

## Body

I should investigate whether it is possible to optimize/deobfuscate the IL that is fed into the decompiler, to allow for cleaner decompilation output.

Preferably, the following optimizations should take place:
- Evaluating pure operations (assuming they cant be hooked) such as `Math.*` or `sizeof`
- Eliminating dead branches. This would include switch statements.

For more advanced implementations, it could also look at existing methods in the binary and check if they are pure. The optimization/deobfuscation logic should be moved to another project/repo, so it can be developed independently.

This may require a custom decompiler, in which case I should look into just copying the existing implementation (since dnSpy is no longer being developed).

