DELIMITER $$

CREATE TRIGGER BefInsUsuario BEFORE INSERT ON Usuario
FOR EACH ROW
BEGIN
    -- Si la contraseña no está ya en formato hash, la encripta
    SET NEW.Contrasenia = SHA2(NEW.Contrasenia, 256);
END $$;


DELIMITER $$
CREATE TRIGGER BefUpdUsuario BEFORE UPDATE ON Usuario
FOR EACH ROW
BEGIN
    -- Solo hashea si se cambió la contraseña
    IF NEW.Contrasenia <> OLD.Contrasenia THEN
        SET NEW.Contrasenia = SHA2(NEW.Contrasenia, 256);
    END IF;
END $$;