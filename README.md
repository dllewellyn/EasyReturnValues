# Easy Return Values

[![Build Status](https://travis-ci.org/dllewellyn/EasyReturnValues.svg?branch=develop)](https://travis-ci.org/dllewellyn/EasyReturnValues)

This project provides a return value which is similar to that used in the Rust programming language. It forces developers to check their return values. 

Example:

```
Option<int> option = Option<int>.None();
Assert.Throws<ArgumentNullException>(() => option.unwrap());

Option<int> option = new Option<int>(5);
Assert.AreEqual(option.unwrap(), 5);


Option<int> option = new Option<int>(5);
Assert.IsTrue(option.IsSome());


Option<int> option = Option<int>.None();
Assert.IsTrue(option.IsNone());
```