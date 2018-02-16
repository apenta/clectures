-- Create the Artist Table
CREATE TABLE Artist
(
	id				int identity(1, 1),     -- Starts first row at value 1, each row increases by 1
	first_name		varchar(50),
	last_name		varchar(50)			not null,
	 
	-- constraint name type (columns)
	CONSTRAINT pk_artist PRIMARY KEY (id)
);

-- Create the Painting Table
CREATE TABLE Painting
(
	id int	identity(1,1),
	title varchar(100) not null,
	artist_id int not null,

	CONSTRAINT pk_painting PRIMARY KEY (id),
	CONSTRAINT fk_painting_artist FOREIGN KEY (artist_id) REFERENCES artist(id)
);


-- Create the Customer Table
CREATE TABLE Customer
(
	id			int identity(1,1),
	first_name	varchar(50)			not null,
	last_name	varchar(50)			not null,
	phone		varchar(12)			null,
	address		varchar(50)			not null,
	postal_code varchar(10)			not null,
	district	char(2)				not null,

	CONSTRAINT pk_customer PRIMARY KEY (id)
);

-- Create the Purchase Table
CREATE TABLE Purchase
(
	id			int		identity(1,1),
	sales_price	money	not null,
	sale_date	date	not null,
	painting_id	int		not null,
	customer_id	int		not null,

	CONSTRAINT pk_purchase PRIMARY KEY (id),	
	CONSTRAINT fk_purchase_painting FOREIGN KEY (painting_id) REFERENCES painting(id),
	CONSTRAINT fk_purchase_customer FOREIGN KEY (customer_id) REFERENCES customer(id),
	CONSTRAINT uq_purchase_date_painting_customer UNIQUE(sale_date, painting_id, customer_id)

);

SET IDENTITY_INSERT Artist ON;

INSERT INTO Artist (id, first_name, last_name) VALUES (1, 'Vincent', 'van Gogh');
INSERT INTO Artist (id, first_name, last_name) VALUES (2, 'Claude', 'Monet');

SET IDENTITY_INSERT Artist OFF;


SET IDENTITY_INSERT Painting ON;

INSERT INTO Painting (id, title, artist_id) VALUES (1, 'Starry Night', 1);
INSERT INTO Painting (id, title, artist_id) VALUES (2, 'Self Portrait', 1);
INSERT INTO Painting (id, title, artist_id) VALUES (3, 'Sunflowers', 1);
INSERT INTO Painting (id, title, artist_id) VALUES (4, 'Water Lillies', 2);

SET IDENTITY_INSERT Painting OFF;




DROP TABLE Purchase;
DROP TABLE Painting;
DROP TABLE Customer;
DROP TABLE Artist;