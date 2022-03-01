CREATE TABLE Categorias(
	Id SERIAL PRIMARY KEY,
	Name VARCHAR(70),
	Description TEXT
);


CREATE TABLE Produtos(
	Id SERIAL PRIMARY KEY,
	Name VARCHAR(70) NOT NULL,
	Description TEXT,
	Value NUMERIC CHECK(Value >= 0) NOT NULL DEFAULT 0.,
	Brand VARCHAR(80),
	Category_Id INT REFERENCES Categorias(Id)
);