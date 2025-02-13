CREATE DATABASE torpetarna character set utf8 collate utf8_hungarian_ci; 
CREATE TABLE `torpetarna`.`kozetek` ( `id` INT(3)  AUTO_INCREMENT, `nev` VARCHAR(20), PRIMARY KEY (`id`) );

CREATE TABLE `torpetarna`.`torpek` ( `id` INT(3)  AUTO_INCREMENT, `nev` VARCHAR(30), `klan` VARCHAR(30), `nem` VARCHAR(1), `suly` INT(3), `magassag` VARCHAR(3), PRIMARY KEY (`id`) ) ;

CREATE TABLE `torpetarna`.`tarnak` ( `id` INT(3)  AUTO_INCREMENT, `nev` VARCHAR(30) , `kozet_id` INT(3) , PRIMARY KEY (`id`));

CREATE TABLE `torpetarna`.`kihol` ( `torpe_id` INT(3) , `tarna_id` INT(3) , `kitermelt_mennyiseg` INT(3));

