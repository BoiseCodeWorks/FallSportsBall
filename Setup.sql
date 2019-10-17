USE canadianball;

-- CREATE TABLE users
-- (
--     id VARCHAR(255) NOT NULL,
--     username VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL UNIQUE,
--     hash VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- );
CREATE TABLE teams
(
    id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    mascot VARCHAR(255) NOT NULL,

    PRIMARY KEY (id)
);

CREATE TABLE players
(
    id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    teamId INT,

    FOREIGN KEY (teamId)
        REFERENCES teams(id),
        
    PRIMARY KEY (id)
);

CREATE TABLE games
(
    homeTeamId INT NOT NULL,
    awayTeamId INT NOT NULL,
    winnerId INT NOT NULL,
    id INT NOT NULL AUTO_INCREMENT,

    FOREIGN KEY (homeTeamId)
        REFERENCES teams(id),
    FOREIGN KEY (awayTeamId)
        REFERENCES teams(id),
    FOREIGN KEY (winnerId)
        REFERENCES teams(id),
        
    PRIMARY KEY (id)

)