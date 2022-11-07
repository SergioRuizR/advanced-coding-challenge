# Hello #Futureshaper
I am glad that you passed the first stages of the interview process. Now is the time to show us what you got with the following full-stack challenge! 

## The objective: 
Develop an end-to-end TODO list application.

## System prerequisites:
- Docker Desktop (supporting Linux containers)
- docker-compose
- nodeJS (>=16.18)
- Visual Studio 2019
- .NET Core 3.1 SDK

## What we expect from you:
-	The task is simple, now is the time for you to shine and go the extra mile! Be sure to show your capabilities, if you got a great idea be sure to implement it…. Think big and make it happen. 
-	We strongly value good aesthetics and great UX, don’t be shy to get the artist out of you. 
-	We know that you may forget the way to implement certain functionalities, you can use code snippets as necessary, however, be sure to NOT PLAGIARIZE a whole solution. 
-	Feel at home and use the libraries and extensions that you need. Just be sure to document and declare the dependencies needed to be used in other machines to be evaluated.

## Problem statement
The Labor Management System (LMS) team from Honeywell is having trouble to manage todos tasks added in the basecode. They need a centralized way to store and display the todos from the team so that they have all these pending tasks considered in future sprints. You are provided a scaffolded structure of a solution, which consist of the following:

- A base React TODOs management App for TODOs management. The view looks as follows:

![TODO WebApp](https://github.com/DaBullet/advanced-coding-challenge/blob/main/media/Todo-webapp.png)

- An empty .NET Core 3.1 Web API solution

What you need to do for each component is described as follows:

- React App
    - Implement POST, GET and DELETE TODOs
        - Add a delete button for each element in the TODO list, as depicted below:

            ![TODO WebApp](https://github.com/DaBullet/advanced-coding-challenge/blob/main/media/Todo-webapp-delete-button.png)

        - Send the corresponding request for each operation to the .NET Core Web API
            - You MAY use any request library you prefer (axios, fetch API, SWR, etc).

- Web API
    - Create and implement the POST, GET and DELETE endpoints in the TODO controller
        - For this challenge, we will skip the database persistance. You MUST persist the TODOs in the application memory.
        - Try to structure the code as decoupled as possible.
        - Authentication and authorization SHOULD be skipped.

Once finished, challenge yourself and try to deploy both components in your Docker host using the docker-compose and Dockerfile already provided in this repository. You MIGHT need to create a network to communicate both components.

## Final notes:
- It is not required to push your changes to this repository. If you wish, you can fork it and keep it in your personal/private repository.
- Try to code as clean as possible. Think of it as it you were tasked in real life.

**Good luck!**
