## 1. feladat
### konzolos
tesztelni még nem tudtam, elvileg minden jó

***TODO***: a classekben a fieldeket publicra kéne rakni + (get, private set) és akkor működne az adatok beolvasása

### gui
error a nevek betöltésénél
```bash
connection must be valid and open
```

## 3. feladat
migration, model megvan
ez az error egyelőre 
```bash
  SQLSTATE[42S01]: Base table or view already exists: 1050 Table 'ingatlanok' already exists (Connection: mysql, SQL: create table `ingatlanok` (`id` bigint unsigned not null auto_increment primary key, `kategoria` int not null, `nev` varchar(255) not null, `leiras` varchar(255) not null, `hirdetesDatuma` date not null default '2025-02-14 10:14:45', `tehermentes` tinyint(1) not null, `ar` int not null, `kepUrl` varchar(255) not null) default character 
set utf8mb4 collate 'utf8mb4_unicode_ci')
```