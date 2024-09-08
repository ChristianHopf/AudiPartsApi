CREATE TYPE ServiceRecord AS (
    owner VARCHAR(64),
    date DATE,
    make VARCHAR(64),
    model VARCHAR(64),
    year SMALLINT,
    vin CHAR(17),
    license VARCHAR(10),
    mileage INT,
    service TEXT,
    charge NUMERIC(10, 2)
)