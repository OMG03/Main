use sys;

create database tournaments;
use tournaments;

create table nationalities (
	nationality_id int,
    label varchar(30) null,
    constraint pk_nationality_id primary key (nationality_id)
);

create table players (
	player_id int,
	first_name varchar(30) not null,
	last_name varchar(30) not null,
	age tinyint unsigned not null,
    nationality_id 	int not null,
	constraint pk_player_id primary key (player_id),
    constraint fk_players_nationalities_nationality_id foreign key (nationality_id) 
		references nationalities(nationality_id)
);

create table tournaments (
	tournament_id int,
    title varchar(30),
    date_open date not null,
    date_close date,
    price decimal(7, 2) not null,
    constraint pk_tournament_id primary key (tournament_id)
);

create table ranks (
	rank_id int,
    title varchar(30) not null,
    constraint pk_ranks_rank_id primary key (rank_id)
);

create table players_tournaments (
	player_id int,
    tournament_id int,
    points int,
    rank_id int,
    constraint pk_players_tournaments_player_id_tournament_id primary key (player_id, tournament_id),
    constraint fk_players_tournaments_players_player_id foreign key (player_id)
		references players(player_id),
	constraint fk_players_tournaments_tournaments_tournament_id foreign key (tournament_id)
		references tournaments(tournament_id),
	constraint fk_players_tournamets_ranks_rank_id foreign key (rank_id)
		references ranks(rank_id)
);

-- We don't need tables for tournament_wins or tournament_points

-- That's why I've named all ids table_name_id
-- SELECT * FROM players JOIN nationalities USING (nationality_id);
  