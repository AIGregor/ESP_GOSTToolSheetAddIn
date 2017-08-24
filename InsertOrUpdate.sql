IF EXISTS (SELECT * FROM tblCuttingToolParameter 
	WHERE fldCLFileCode_tblCuttingToolParameter = 9999 AND 
		  fldfkCuttingToolId_tblCuttingToolParameter = 'ffcd3f76-a173-4a7d-959b-43fbf32f0011')
	BEGIN
	   UPDATE tblCuttingToolParameter
	   SET fldValue_tblCuttingToolParameter = 'New old text'
	   WHERE fldCLFileCode_tblCuttingToolParameter = 9999 
		  AND fldfkCuttingToolId_tblCuttingToolParameter = 'ffcd3f76-a173-4a7d-959b-43fbf32f0011'
	END
ELSE
	BEGIN
	  INSERT INTO tblCuttingToolParameter
	  (fldCLFileCode_tblCuttingToolParameter, 
	  fldfkCuttingToolId_tblCuttingToolParameter,
	  fldValue_tblCuttingToolParameter) 
	  VALUES (9999, 'ffcd3f76-a173-4a7d-959b-43fbf32f0011', 'New new text')
	END;