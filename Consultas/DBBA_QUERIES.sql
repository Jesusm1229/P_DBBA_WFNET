
--insert into books
drop function books_insert()
create or replace function books_insert
(
	_isbn character varying,
	_tittle character varying,
	_author character varying,
	_year integer
)returns int as
$$
begin
	insert into books
	(
		isbn,
		tittle,
		author,
		year
	)values
	(
		_isbn,
		_tittle,
		_author,
		_year
	);
	
	if found then
		return 1; --Success
	else 
		return 0; --Fail
	end if;

end
$$
language plpgsql


--Insert values from books to author

INSERT INTO authors(idbook, name) 
SELECT id, author FROM books;


--select function books
drop function books_select()
create or replace function books_select(

)
returns table
(
	_id integer,
	_isbn character varying,
	_tittle character varying,
	_author character varying,
	_year integer
)as
$$
begin
	return query
	select id, isbn, tittle, author, year from books;
end
$$
language plpgsql

select * from books_select();


--select function authors
drop function au_select()
create or replace function au_select()
returns table
(
	_idbook integer,
	_name character varying
)as
$$
begin
	return query
	select idbook, name from authors;
end
$$
language plpgsql

select * from au_select();


--OTHERS QUERYS

TRUNCATE TABLE books,authors RESTART IDENTITY;

select * from books_select();
select * from au_select();


DELETE FROM authors;
DELETE FROM books;


CREATE TABLE Authors (
idBook integer NOT NULL REFERENCES Books(id),
Name varchar(55) NOT NULL,
PRIMARY KEY (idBook, Name))

CREATE TABLE books (
    id serial PRIMARY KEY,
    isbn varchar(50) UNIQUE NOT NULL,
    tittle varchar(150) NOT NULL,
    author varchar(150) NOT NULL,
    year integer NOT NULL
);

