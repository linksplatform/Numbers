#!/bin/bash
set -e # Exit with nonzero exit code if anything fails

# Generate tex file
bash format-document.sh > document.tex

# Generate pdf
latex -shell-escape document.tex
makeindex document
latex -shell-escape document.tex
dvipdf document.dvi document.pdf
dvips document.dvi

# Copy pdf to publish location (with be used in the next script)
mkdir _site
cp document.pdf _site/Platform.${TRAVIS_REPO_NAME}.pdf
