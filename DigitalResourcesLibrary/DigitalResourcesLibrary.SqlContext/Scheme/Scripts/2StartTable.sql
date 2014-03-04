CREATE TABLE `locale` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `locale` varchar(10) COLLATE utf8_bin NOT NULL,
  `language` varchar(45) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `locale_UNIQUE` (`locale`),
  UNIQUE KEY `language_UNIQUE` (`language`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
INSERT INTO `locale` VALUES (1,'ru','Русский'),(2,'be','Беларускі'),(3,'en','English');



CREATE TABLE `role` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(45) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
INSERT INTO `role` VALUES (1,'ROLE_ADMIN'),(2,'ROLE_USER');


CREATE TABLE `tag` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `meta` varchar(255) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
INSERT INTO `tag` VALUES (1,NULL),(2,NULL),(3,NULL),(4,NULL),(6,NULL),(7,NULL),(8,NULL),(9,NULL),(10,NULL),(11,NULL),(12,NULL),(13,NULL);


