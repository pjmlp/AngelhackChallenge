# Introduction

This is a simple command application developed in F# to solve the AngelHack Athens 2015 code challenge

# Challenge description

The following description was taken directly from the challenge page.

Figure out this challenge to get a promo code for a free ticket! Your challenge is to read in a string of Braille characters (using
standard English Braille defined [here](http://en.wikipedia.org/wiki/English_Braille)) and print off the word in standard English letters.

The input will consistent of an array of 2x6 space-delimited Braille characters. This array is always on the same line, so regardless
of how long the text is, it will always be on 3-rows of text. A lowered bump is a dot character '.', while a raised bump
is an upper-case 'O' character.

Ex: This Input translates to helloworld
```
O. O. O. O. O. .O O. O. O. OO 
OO .O O. O. .O OO .O OO O. .O
.. .. O. O. O. .O O. O. O. ..
```
Print the transcribed braille below to get the promo code!
```
.O O. .O OO O. O. .O OO O. OO O. .O O. .O
O. .O O. .. .. OO OO .. .. .. OO OO .O OO
O. O. O. O. .. O. O. O. OO .. .. .O O. .O
```

# Solution

The file _Program.fs_ contains the F# solution, with the files _hello.txt_ and _challenge.txt_ containing the encodings above.