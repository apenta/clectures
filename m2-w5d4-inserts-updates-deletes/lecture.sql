-- Constraints



-- INSERT DATA
-- Let's add Klingon to the languages in the database.




-- Referential integrity requires that foreign keys point to valid primary keys.


-- let's confirm once we get the insert to work


-- Add another new language, Klinglish.


-- INSERTS allow us to rearrange the column names in the list, we just need to make sure the values match.



-- DELETE
-- Let's delete all the Klingon, Klingish, and Englon rows we just added, starting with Englon.

-- SELECT to confirm the deletion



-- The WHERE clause can have other conditions besides equals. 
 -- We can could do `language='Klingon' or language='Klinglish'`. 
 -- We might even do something daring, `'language LIKE 'Kling%'`, and remove the rows with a wildcard LIKE.  
 -- BETWEEN n AND n+1` is also a really handy technique for deleting rows within a range of values, such numeric keys.

 


 



-- UPDATE
-- Let's start by adding back Klingon.





-- TRANSACTIONS
-- Let's wrap updating the Klingon row in a trasaction. Begin by noting the current values for isofficial and percentage.



