(defun C:ACGEXPORT()											;define the function

(setq putanja
	(getfiled "Putanja: " "c:/program files/<AutoCAD installation directory>/support/" "dxf" 1)	; specify the name and path of a 
)													; new file
 

(setq SelSet (ssget "_X" '((-3 ("ACG_ANNOTATION")))))	; select all objects which have the registered application "ACG_ANNOTATION"
							; attached to their xdata and save the selection set to variable "SelSet"

(command "._DXFOUT" putanja "O" SelSet "" 16)		; run the DXFOUT command, save the file to the predefined path, select objects
							; from selection set defined with SelSet, "O" acitavtes the option to select objects 

(princ)							; exit quietly

)							; end of defun

