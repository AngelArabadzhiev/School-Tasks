use geography;

CREATE FUNCTION meters_to_feet(height INT)
RETURNS INT
BEGIN
   DECLARE elevation_in_feet INT;
   SET elevation_in_feet = height * 3.281;
   RETURN elevation_in_feet;
END;

CREATE FUNCTION kilometers_to_miles(length INT)
    RETURNS INT
BEGIN
    DECLARE length_in_miles INT;
    SET length_in_miles = length * 1.609;
    RETURN length_in_miles;
END;

CREATE FUNCTION sq_kilometers_to_sq_miles(area INT)
    RETURNS INT
BEGIN
    DECLARE length_in_miles INT;
    SET length_in_miles = area * 0.386102;
    RETURN length_in_miles;
END;

SELECT peak_name,CONCAT(meters_to_feet(elevation), ' ft') as 'Elevation in feet'FROM peaks;

SELECT river_name,CONCAT(kilometers_to_miles(length), ' mi') as 'Length in miles'FROM rivers;

SELECT country_name,CONCAT(sq_kilometers_to_sq_miles(are_in_sq_km), ' sq. mi') as 'Area in square miles'FROM countries;
