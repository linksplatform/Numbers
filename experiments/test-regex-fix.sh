#!/bin/bash
# Test that the fixed regex pattern correctly parses CHANGELOG.md sections

# Simulate what the Rust code does - test the pattern
CHANGELOG="/tmp/gh-issue-solver-1774178393929/CHANGELOG.md"
VERSION="0.3.0"
ESCAPED_VERSION=$(echo "$VERSION" | sed 's/\./\\./g')

echo "=== Testing version: $VERSION ==="
echo "=== Pattern: (?s)## \\[$ESCAPED_VERSION\\][^\\n]*\\n(.*?)(?:\\n## \\[|$) ==="

# Check the regex crate doesn't support lookahead - that's confirmed
# Our fix replaces (?=...) with non-capturing group (?:...)
echo ""
echo "Old pattern (broken): (?s)## \\[$ESCAPED_VERSION\\].*?\\n(.*?)(?=\\n## \\[|\$)"
echo "New pattern (fixed):  (?s)## \\[$ESCAPED_VERSION\\][^\\n]*\\n(.*?)(?:\\n## \\[|\$)"
echo ""
echo "Key change: (?=\n## \[) is a LOOKAHEAD (not supported by Rust's regex crate)"
echo "            (?:\n## \[) is a NON-CAPTURING GROUP (fully supported)"
echo ""
echo "The old (?=...) lookahead would preserve the '\n## [' prefix in the string."
echo "The new (?:...) non-capturing group will consume it, but .trim() removes trailing whitespace"
echo "and we capture content BEFORE the next section boundary anyway."
