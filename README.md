# Student/Course Data
In my project, I have decided to create an "Student Records" API, because I want to explore what types of data that student records are included. It is common that they include the student ID, first name, last name, GPA, and their current course (Students could only take one course at a time for simplciity of this project). Student records serve a variety of purposes including keeping track of grades, verifying enrollment, etc.

I have created two controllers which are called `StudentsController` and `CoursesController` which allows us to manipulate data from both the Courses and Students tables. My project partially follows the MVC Architecture Pattern (for the GET and PUT HTTP methods). I have used 10 API endpoints, and 4 different HTTP methods.

## What are the API endpoints?
### 1) `GET` - /api/studentdata
* This first API endpoint simply lists all the students and its related data. There is no request body, but there is a response body.
#### Response body
```
{
    "statusCode": 200,
    "statusDescription": "One or more students found",
    "getStudents": [
        {
            "emplid": 23888261,
            "firstName": "Anthony John",
            "lastName": "Regner",
            "courseId": "CSCI 15000",
            "semester": null,
            "gpa": null,
            "course": null
        },
        {
            "emplid": 28239425,
            "firstName": "Matheus2",
            "lastName": "Discrete",
            "courseId": "CSCI 15000",
            "semester": 5,
            "gpa": 2.6,
            "course": null
        },
        {
            "emplid": 28642813,
            "firstName": "Matheus",
            "lastName": "Discrete",
            "courseId": "CSCI 15000",
            "semester": null,
            "gpa": null,
            "course": null
        }
    ]
}
```

### 2) `GET` - /api/studentdata/[id]
* This API endpoint lists student data from a certain ID. The response body shows student data from just that ID.
#### Response body
```
{
    "statusCode": 200,
    "statusDescription": "Student 28642813 found",
    "getStudents": [
        {
            "emplid": 28642813,
            "firstName": "Matheus",
            "lastName": "Discrete",
            "courseId": "CSCI 15000",
            "semester": null,
            "gpa": null,
            "course": null
        }
    ]
}
```

### 3) `POST` - /api/studentdata (does not follow MVC Architecture Pattern)
* This API endpoint adds student data if that ID doesn't already exist. If that ID exists, it returns a 409 Conflict error. Upon successful addition, it returns a 201 Created status.
#### Request body
```
{
    "emplid": 24631686,
    "firstName": "Ifthen",
    "lastName": "Xor",
    "semester": 3,
    "gpa": 2.93,
    "courseId": "CSCI 15000"
}
```

#### Response body
```
{
    "emplid": 24631686,
    "firstName": "Ifthen",
    "lastName": "Xor",
    "courseId": "CSCI 15000",
    "semester": 3,
    "gpa": 2.93,
    "course": null
}
```

### 4) `PUT` - /api/studentdata/[id]
* This API endpoint modifies the existing data based on the ID. If the ID is not found, it returns a 400 Bad Request error. Since we are only modifying data, we don't need to have a response body. The response body would have "no content" anyway.
#### Request body
```
{
    "emplid": 24631686,
    "firstName": "Ifthen",
    "lastName": "Nor",
    "semester": 3,
    "gpa": 3.07,
    "courseId": "CSCI 15000"
}
```

### 5) `DELETE` - /api/studentdata/[id]
* This API endpoint deletes student data based on the ID.  If the ID is not found, it returns a 404 Not Found error. Neither the request nor the response body is needed.

The remainder of the API endpoints are as follows:
* 6) `GET` - /api/coursedata
* 7) `GET` - /api/coursedata/[id]
* 8) `POST` - /api/coursedata
* 9) `PUT` - /api/coursedata/[id]
* 10) `DELETE` - /api/coursedata/[id]
