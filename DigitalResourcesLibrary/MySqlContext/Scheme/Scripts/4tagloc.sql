CREATE TABLE `tagloc` (
  `tag` int(11) NOT NULL,
  `locale` int(11) NOT NULL,
  `value` varchar(45) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`tag`,`locale`),
  KEY `fk_tagloc_tag1_idx` (`tag`),
  KEY `fk_tagloc_locale1_idx` (`locale`),
  CONSTRAINT `fk_tagloc_locale1` FOREIGN KEY (`locale`) REFERENCES `locale` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tagloc_tag1` FOREIGN KEY (`tag`) REFERENCES `tag` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
INSERT INTO `tagloc` VALUES (1,1,'Ключевое слово'),(1,2,'Ключавое слова'),(1,3,'Key word'),(2,1,'Стихи'),(2,2,'Вершы'),(3,1,'Библиография'),(3,2,'Бібліяграфія'),(4,1,'Памятник '),(4,2,'Помнік'),(6,1,'История'),(6,2,'Гісторыя'),(7,1,'Архитектура'),(7,2,'Архітэктура'),(8,1,'Проза'),(8,2,'Проза'),(9,1,'Замки'),(9,2,'Замкі'),(10,1,'Зодчество'),(10,2,'Дойлідства'),(11,1,'Наследие'),(11,2,'Спадчына'),(12,1,'Литература'),(12,2,'Літаратура'),(13,1,'Поэт'),(13,2,'Паэт');
