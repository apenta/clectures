-- Constraints
SELECT * FROM INFORMATION_SCHEMA.CHECK_CONSTRAINTS;
SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS;


-- INSERT DATA
-- Let's add Klingon to the languages in the database.
INSERT INTO countrylanguage VALUES ('USA', 'Elvish', 1, 11.2);
INSERT INTO countrylanguage (isofficial, language, countrycode, percentage) VALUES (1, 'Elvanese', 'USA', 0.1);

SELECT * FROM countrylanguage WHERE countrylanguage.countrycode = 'USA';



-- Referential integrity requires that foreign keys point to valid primary keys.
INSERT INTO countrylanguage VALUES ('ZZZ', 'Esperanto', 1, 11.2);


-- Move USA to the Outer Space continent
UPDATE country
SET continent = 'South America'
WHERE code = 'USA';



-- let's confirm once we get the insert to work


-- Add another new language, Klinglish.


-- INSERTS allow us to rearrange the column names in the list, we just need to make sure the values match.



-- DELETE
-- Let's delete all the Klingon, Klingish, and Englon rows we just added, starting with Englon.

delete from countrylanguage
where countrylanguage.language = 'Elvish';

delete from countrylanguage where countrylanguage.language = 'English';
delete from countrylanguage;


-- SELECT to confirm the deletion
SELECT MAX(city.id) FROM city;
INSERT INTO city VALUES ('Brunswick', 'USA', 'Ohio', 100000);


-- The WHERE clause can have other conditions besides equals. 
 -- We can could do `language='Klingon' or language='Klinglish'`. 
 -- We might even do something daring, `'language LIKE 'Kling%'`, and remove the rows with a wildcard LIKE.  
 -- BETWEEN n AND n+1` is also a really handy technique for deleting rows within a range of values, such numeric keys.

 

 -- VARIABLES
 DECLARE @code char(3); 
 SET @code = (SELECT country.code FROM country WHERE country.name = 'United States');
 
-- SELECT @code;

 DECLARE @language varchar = 'Englon';
 DECLARE @officialLanguage bit = 0;
 DECLARE @spokenByPercentage real = 3.2;

 INSERT INTO countrylanguage VALUES (@code, @language, @officialLanguage, @spokenByPercentage);


 



-- UPDATE
-- Let's start by adding back Klingon.





-- TRANSACTIONS
-- Let's wrap updating the Klingon row in a trasaction. Begin by noting the current values for isofficial and percentage.
INSERT INTO countrylanguage VALUES ('USA', 'Klingon', 1, 10.2);

SELECT * FROM countrylanguage WHERE language = 'Klingon'

BEGIN TRANSACTION

	UPDATE countrylanguage SET percentage = 35.0
	WHERE countrycode = 'USA' AND language = 'Klingon';

ROLLBACK TRANSACTION;

COMMIT TRANSACTION;


