-- ORDERING RESULTS

-- How to randomly sort a table
SELECT * FROM country
ORDER BY NEWID();

-- Populations of all countries in descending order
SELECT name, population 
FROM country
ORDER BY population DESC;


--Names of countries and continents in ascending order
SELECT country.name, country.continent
FROM country
ORDER BY country.continent ASC, country.name ASC;


-- Cities in Ascending Order, Population in Descending Order
SELECT city.name, city.population, city.countrycode
FROM city
ORDER BY city.name ASC, city.population DESC;


-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.
SELECT TOP 10 country.name, country.lifeexpectancy
FROM country
ORDER BY country.lifeexpectancy DESC;

-- Second top 10
SELECT country.name, country.lifeexpectancy
FROM country
ORDER BY country.lifeexpectancy DESC
OFFSET 10 ROWS
FETCH NEXT 10 ROWS ONLY;



-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington. 
-- "city, state", sorted by state then city
SELECT (city.name + ', ' + city.district) AS citystate
FROM city
WHERE city.district IN ('California', 'Oregon', 'Washington')
ORDER BY city.district, city.name;



-- AGGREGATE FUNCTIONS
-- Average Life Expectancy in the World
SELECT AVG(country.lifeexpectancy), country.continent
FROM country
GROUP BY country.continent;

-- Total population in Ohio
SELECT SUM(city.population)
FROM city
WHERE city.district = 'Ohio';

-- Total population per district in the USA
SELECT SUM(city.population) as 'total Population', city.district
FROM city
WHERE city.countrycode = 'USA'
GROUP BY city.district
ORDER BY 'total Population' ASC;


-- The surface area of the smallest country in the world
SELECT MIN(country.surfacearea) FROM country;

-- The 10 largest countries in the world



-- The number of countries who declared independence in 1991
SELECT COUNT(country.indepyear)
FROM country
WHERE country.indepyear = 1991;


-- GROUP BY EXERCISES
-- GROUP BY clusters rows by a column value

SELECT * FROM countrylanguage;

-- Count the number of countries where each language is spoken, order show them from most countries to least
SELECT countrylanguage.language, COUNT(countrylanguage.countrycode) as numberOfCountriesSpoken
FROM countrylanguage
GROUP BY countrylanguage.language
ORDER BY numberOfCountriesSpoken DESC

-- Average life expectancy of each continent ordered from highest to lowest
SELECT country.continent, ROUND(AVG(country.lifeexpectancy), 2) as avglifeexpectancy
FROM country
GROUP BY country.continent
ORDER BY avglifeexpectancy DESC;

-- Exclude Antarctica from consideration for average life expectancy
SELECT country.continent, ROUND(AVG(country.lifeexpectancy), 2) as avglifeexpectancy
FROM country
WHERE country.lifeexpectancy IS NOT NULL
GROUP BY country.continent
ORDER BY avglifeexpectancy DESC;


-- Sum of the population of cities in each state in the USA ordered by state name

-- The average population of cities in each state in the USA ordered by state name

-- The minimum population and the maximum population of each country code


-- Additional samples
-- You may alias column and table names to provide more descriptive names

-- Alias can also be used to create shorthand references, such c for city and co for country.
SELECT DISTINCT countrylanguage.language
FROM countrylanguage;

SELECT DISTINCT cl.language
FROM countrylanguage cl;





-- INNER QUERY
SELECT country.code FROM country WHERE country.indepyear IS NULL;

-- OUTER QUERY
SELECT city.* FROM city WHERE city.countrycode IN ('')



-- SUBQUERY
SELECT city.* 
FROM city 
WHERE city.countrycode IN (
	SELECT country.code FROM country WHERE country.indepyear IS NULL
);

-- Countries in the Top 10 Languages
SELECT countrylanguage.countrycode
FROM countrylanguage WHERE
countrylanguage.language IN (
	SELECT TOP 10 countrylanguage.language
	FROM countrylanguage
	GROUP BY countrylanguage.language
	ORDER BY COUNT(countrylanguage.countrycode) DESC
);



, COUNT(countrylanguage.language)
FROM countrylanguage
GROUP BY countrylanguage.countrycode;






-- cities in those countries
SELECT city.* 
FROM city 
WHERE city.countrycode IN (
	-- countries that have no indep year & speak one of the top 10 languages
	SELECT country.code 
	FROM country 
	WHERE country.indepyear IS NULL
	AND country.code IN (
		-- countries that speak one of top 10 languages
		SELECT countrylanguage.countrycode
		FROM countrylanguage WHERE
		countrylanguage.language IN (
			-- top 10 languages
			SELECT TOP 10 countrylanguage.language
			FROM countrylanguage
			GROUP BY countrylanguage.language
			ORDER BY COUNT(countrylanguage.countrycode) DESC
		)
	)
);