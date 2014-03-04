CREATE TABLE `category` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `parent` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_category_category_idx` (`parent`),
  CONSTRAINT `fk_category_category` FOREIGN KEY (`parent`) REFERENCES `category` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
INSERT INTO `category` VALUES (1,NULL),(3,1),(4,1),(5,1),(6,1),(10,4),(11,10);



CREATE TABLE `categoryloc` (
  `value` varchar(1000) COLLATE utf8_bin DEFAULT NULL,
  `category` int(10) unsigned NOT NULL,
  `locale` int(11) NOT NULL,
  PRIMARY KEY (`category`,`locale`),
  KEY `fk_categoryloc_category1_idx` (`category`),
  KEY `fk_categoryloc_locale1_idx` (`locale`),
  CONSTRAINT `fk_categoryloc_category1` FOREIGN KEY (`category`) REFERENCES `category` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_categoryloc_locale1` FOREIGN KEY (`locale`) REFERENCES `locale` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
INSERT INTO `categoryloc` VALUES ('Гродно в литературе',3,1),('Гродна ў літаратуры',3,2),('Литература',4,1),('Літаратура',4,2),('Искусство ',5,1),('Мастацтва ',5,2),('Историко-культурные памятники Гродно',6,1),('Гісторыка-культурныя помнікі Гродна',6,2),('Писатели',10,1),('Пісьменнікі (персаналіі)',10,2),('Сучкова Т.А.',11,1),('Сучкова Т.А.',11,2);

