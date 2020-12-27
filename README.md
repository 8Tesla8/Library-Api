# Library-Api
web api with reflection for library

## Controllers

### Book

#### Get 
https://localhost:5001/book
https://localhost:5001/book?year=1997&genre=novel

querry parameters: year, author, name, genre

https://localhost:5001/book/simple
https://localhost:5001/book/simple?a=joanne&y=1997

querry parameters:  a, y, n, g

#### Put
https://localhost:5001/book

json body: 
{
    "id": 1,
    "name": "ww",
    "authorId": "2",
    "genreId" : 2,
    "year" : 1880    
}


#### Delete
https://localhost:5001/book?id=1
querry parameters: id

#### Post
https://localhost:5001/book

json body: 
{
    "name": "ww",
    "authorId": "2",
    "genreId" : 2,
    "year" : 1880    
}

### Author

#### Get 
https://localhost:5001/author
https://localhost:5001/author?country=england&name=joanne

querry parameters: name, country

https://localhost:5001/author/simple
https://localhost:5001/author/simple?c=england&n=joanne

querry parameters: n, c

#### Put
https://localhost:5001/author

json body: 
{
    "id": 1,
    "name": "jack london",
    "countryId": "1",
}


#### Delete
https://localhost:5001/author?id=1
querry parameters: id

#### Post
https://localhost:5001/author

json body: 
{
    "name": "jack london",
    "countryId": "1",
}

### Genre

#### Get
https://localhost:5001/genre
https://localhost:5001/genre?name=novel

querry parameters: name

https://localhost:5001/genre/simple
https://localhost:5001/genre/simple?n=novel

querry parameters: n

#### Put
https://localhost:5001/genre

json body: 
{
    "id": 1,
    "name": "detective",
}

#### Delete
https://localhost:5001/genre?id=1
querry parameters: id

#### Post
https://localhost:5001/genre

json body: 
{
    "name": "detective",
}

### Country

#### Get
https://localhost:5001/country
https://localhost:5001/country?name=usa

querry parameters: name

https://localhost:5001/country/simple
https://localhost:5001/country/simple?n=usa

querry parameters: n

#### Put
https://localhost:5001/country

json body: 
{
    "id": 1,
    "name": "usa",
}

#### Delete
https://localhost:5001/country?id=1
querry parameters: id

#### Post
https://localhost:5001/country

json body: 
{
    "name": "china",
}
