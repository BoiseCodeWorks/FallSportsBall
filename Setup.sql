USE canadianball;

-- CREATE TABLE users
-- (
--     id VARCHAR(255) NOT NULL,
--     username VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL UNIQUE,
--     hash VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- );

CREATE TABLE players
(
    id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    teamId INT,

    FOREIGN KEY (teamId)
        REFERENCES teams(id),
        
    PRIMARY KEY (id)
);