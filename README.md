# ULSolutions technical test
The Exercise: 

Write a C# web-based API application that evaluates a string expression consisting of non-negative integers and the + - / * operators only, considering the normal mathematical rules of 
operator precedence. Support for brackets is not required. 
The calculation should be performed in the API not the UI and by your own code, not a third-party library. 


Completed by: 

Sako977/Sache (Old GitHub username)


Summary:

The approach is pretty straight forward,  basic validation and error handling is done at the controller level so that logic is not touched if it is not need. If the request is valid, logic is accessed which is sperated as a class library named 'OperationService' to encapsulate, seprating webservice parts and logic calcualtion. Abstract factory method is used for 'OperationService', base class inheriting from an interface.
Before performing any logic proccessing, regex is used to filter '+-/*' operations in a sequence to follow BODMAS rule. Hence,  calculation is performed first on divide,  then multiply, then addition, and subtraction since support for brackets are not required for this task. Sanity check on the symbols are also performed frequently to ensure accuracy.
Any calcualtion performed is removed fom the string expression.  At the end,  there my be a single value remaning in that case add it as part of result as well. If not sum of all divide, multiply, add, subtract operation is the reuslt.
Unit test is performed to check integrity of the logic programmed. 

A html file contaning a simple UI and a javascript function is added so that a 'GET' request can be performed. To support this, cross-origin request are enabled server-side. 



