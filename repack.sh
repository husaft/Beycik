#!/bin/sh

cd Beycik/Beycik.Model.Tests/Resources
rm model_v3.7z
rm model_v4.7z
7z a -t7z -mx9 model_v3.7z v3
7z a -t7z -mx9 model_v4.7z v4
cd ../../..

cd Beycik/Beycik.PDF.Tests/Resources
rm model_v3.7z
rm model_v4.7z
7z a -t7z -mx9 model_v3.7z v3
7z a -t7z -mx9 model_v4.7z v4
cd ../../..
