-- SELECT ... FROM
-- Selecting the names for all countries
SELECT country.name FROM country;


-- Selecting the name and population of all countries
SELECT country.name, country.population
FROM country;


-- Selecting all columns from the city table
SELECT *
FROM city;


-- SELECT ... FROM ... WHERE
-- Selecting the cities in Ohio
SELECT * 
FROM city
WHERE city.district = 'Ohio';


-- Selecting countries that gained independence in the year 1776
SELECT *
FROM country
WHERE country.indepyear = 1776;


-- Selecting countries not in Asia
SELECT * 
FROM country
WHERE country.continent != 'Asia';

SELECT * FROM country WHERE country.continent <> 'Asia'; -- AND country.continent <> 'South America' AND country.continent <> 'North America';

SELECT * FROM country WHERE country.continent NOT IN ('Asia') --, 'South America', 'North America');


-- Selecting countries that do not have an independence year
SELECT * 
FROM country
WHERE country.indepyear IS NULL;


-- Selecting countries that do have an independence year
SELECT * FROM country
WHERE country.indepyear IS NOT NULL;


-- Selecting countries that have a population greater than 5 million
SELECT * 
FROM country WHERE country.population > 5000000;



-- SELECT ... FROM ... WHERE ... AND/OR
-- Selecting cities in Ohio and Population greater than 400,000
SELECT * FROM city
WHERE city.population > 400000 AND city.district = 'Ohio';

-- Selecting country names on the continent North America or South America
SELECT country.name FROM country
WHERE country.continent = 'North America' OR country.continent = 'South America';



-- SELECTING DATA w/arithmetic
-- Selecting the population, life expectancy, and population per area
--	note the use of the 'as' keyword

SELECT country.name, country.population, country.lifeexpectancy, (country.population / country.surfacearea) as populationperarea
FROM country
WHERE (country.population / country.surfacearea) > 500.0;
--WHERE populationperarea > 500;
