#!/bin/bash

cd pwd

cd jni

echo "start clean last so files"

ndk-build clean 

ndk-build

echo "make new so success"

cd ../libs

cp -f armeabi-v7a/libXTable.so ../../../Assets/Plugins/Android/libs/armeabi-v7a/libXTable.so

cp -f x86/libXTable.so ../../../Assets/Plugins/Android/libs/x86/libXTable.so

echo "copy so success, bye!"
