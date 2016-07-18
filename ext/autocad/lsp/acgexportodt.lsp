(defun C:acgexportodt()

(vl-load-com)

(defun C:acgparcel()

(setq tabldefn 
    '(("tablename" . "Parcel")  
       ("tabledesc" . "Katastarska parcela.") 
       ("columns" 
            ; Define a field 
            (("colname" . "DataSourceAuthority") 
             ("coldesc" . "Oficijelni autor izvornih prostornih podataka.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

            ; Define more fields as needed 
	    (("colname" . "BlockNumber") 
             ("coldesc" . "Oznaka (broj) bloka kome parcela pripada.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

	    ; Define a field 
            (("colname" . "Number") 
             ("coldesc" . "Broj katastarske parcele.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

            ; Define more fields as needed 
	    (("colname" . "CountryName") 
             ("coldesc" . "Naziv države u kojoj se parcela nalazi.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

	    ; Define a field 
            (("colname" . "StateName") 
             ("coldesc" . "Naziv entiteta (republike, pokrajine) u kome se parcela nalazi.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

            ; Define more fields as needed 
	    (("colname" . "DataSourceYearCreated") 
             ("coldesc" . "Godina izrade prostornih podataka.")  
             ("coltype" . "integer") 
             ("defaultval" . "0")
		)

	    ; Define a field 
            (("colname" . "GUID") 
             ("coldesc" . "Jedinstveni identifikator")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

            ; Define more fields as needed 
	    (("colname" . "DataSourceURL") 
             ("coldesc" . "URL adresa (hiperlink) prostornog podatka.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

	    ; Define a field 
            (("colname" . "SubmissionNames") 
             ("coldesc" . "Imena i prezimena podnosilaca zahtjeva.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

            ; Define more fields as needed 
	    (("colname" . "DataSourceAuthor") 
             ("coldesc" . "Izradivac digitalnih prostornih podataka.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

	    ; Define a field 
            (("colname" . "CadastralUnitName") 
             ("coldesc" . "Naziv katastarske opštine u u kojoj se parcela nalazi.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

            ; Define more fields as needed 
	    (("colname" . "DataSourceMethod") 
             ("coldesc" . "Metoda akvizicije izvornih prostornih podataka.")  
             ("coltype" . "integer") 
             ("defaultval" . "0")
		)

	    ; Define a field 
            (("colname" . "DataSourceMonthCreated") 
             ("coldesc" . "Mjesec izrade prostornih podataka.")  
             ("coltype" . "integer") 
             ("defaultval" . "0")
		)

            ; Define more fields as needed 
	    (("colname" . "Type") 
             ("coldesc" . "Primarna namjena površine pod parcelom.")  
             ("coltype" . "integer") 
             ("defaultval" . "0")
		)

	    ; Define a field 
            (("colname" . "TypeL0") 
             ("coldesc" . "Primarna namjena površine pod parcelom.")  
             ("coltype" . "integer") 
             ("defaultval" . "0")
		)

            ; Define more fields as needed 
	    (("colname" . "TypeL1") 
             ("coldesc" . "Sekundarna namjena površine pod parcelom u okviru primarne namjene.")  
             ("coltype" . "integer") 
             ("defaultval" . "0")
		)

	    ; Define more fields as needed 
	    (("colname" . "TypeL2") 
             ("coldesc" . "Tercijalna namjena površine pod parcelom u okviru sekundarne namjene.")  
             ("coltype" . "integer") 
             ("defaultval" . "0")
		)

	    ; Define a field 
            (("colname" . "LocationDescription") 
             ("coldesc" . "Dodatni tekstualni opis lokacije na kojoj se parcela nalazi.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

            ; Define more fields as needed 
	    (("colname" . "MunicipalityName") 
             ("coldesc" . "Naziv opštine u kojoj se parcela nalazi.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

	    ; Define more fields as needed 
	    (("colname" . "SubNumber") 
             ("coldesc" . "Podbroj katastarske parcele.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

	    ; Define more fields as needed 
	    (("colname" . "FootprintSurface") 
             ("coldesc" . "Ukupna izracunata površina parcele (kvm).")  
             ("coltype" . "real") 
             ("defaultval" . "0")
		)

	    ; Define a field 
            (("colname" . "FootprintSurfaceFixed") 
             ("coldesc" . "Ukupna zadata površina parcele (kvm).")  
             ("coltype" . "real") 
             ("defaultval" . "0")
		)

            ; Define more fields as needed 
	    (("colname" . "DataSourceScale") 
             ("coldesc" . "Razmjera izvornih prostornih podataka.")  
             ("coltype" . "integer") 
             ("defaultval" . "0")
		)

	    ; Define more fields as needed 
	    (("colname" . "RegionName") 
             ("coldesc" . "Naziv regiona (dijela države, kantona) u kome se parcela nalazi.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

	    ; Define more fields as needed 
	    (("colname" . "Status") 
             ("coldesc" . "Tekuce stanje katastarske parcele.")  
             ("coltype" . "integer") 
             ("defaultval" . "0")
		)

	    ; Define more fields as needed 
	    (("colname" . "PreviousNumber") 
             ("coldesc" . "Broj katastarske parcele u starom premjeru.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

	    ; Define a field 
            (("colname" . "ForeignKey") 
             ("coldesc" . "Kljuc iz eksterne tabele")  
             ("coltype" . "integer") 
             ("defaultval" . "0")
		)

            ; Define more fields as needed 
	    (("colname" . "SoilType") 
             ("coldesc" . "Vrsta zemljišta pod parcelom.")  
             ("coltype" . "integer") 
             ("defaultval" . "0")
		)

	    ; Define a field 
            (("colname" . "SubmissionFlag") 
             ("coldesc" . "Indikator podnesenih zahtjeva nad katastarskom parcelom.")  
             ("coltype" . "integer") 
             ("defaultval" . "0")
		)

            ; Define more fields as needed 
	    (("colname" . "ZoneNumber") 
             ("coldesc" . "Oznaka (broj) zone kojoj parcela pripada.")  
             ("coltype" . "character") 
             ("defaultval" . "nil")
		)

	    
	    )))

	; Create the new table
	(ade_oddefinetab tabldefn)

	)




(defun C:selpol()
(setq selekcija (ssget "_X" (list (cons 0 "MPOLYGON")(cons 8 "ACG_PARCELA")(cons 70 1)))) ;(sssetfirst nil selekcija)
)

(defun C:sstolist ()
 (setq sscnt 0 
sslist nil)
 (repeat (sslength selekcija)
  (setq sslist (cons (ssname 
selekcija sscnt) sslist))
  (setq sscnt (1+ 
sscnt))
 )
;(setq file_handle (open "C:\\Users\\INOVA\\Desktop\\Data.txt" "a"))
;(print sslist file_handle) Da ispise listu u txt fajl. Trenutno nije potrebno ali nka ga.
 (princ)


)

(C:SELPOL)
(C:SSTOLIST)
(C:acgparcel)


(setq i 0);counter to iterate the collection
(repeat (sslength selekcija);repeat the ss collection
(setq ent (ssname selekcija i));get the entity name
(ade_odaddrecord ent "parcel");add OD table
(setq i ( + i 1));increment the counter
);repeat


(while (/= sslist nil)

(setq a (car sslist))

(setq b (cdr sslist))

(setq dada0 (vla-get-area (vlax-ename->vla-object a)))

(setq dada(assoc -3 (entget a '("ACG_PARCEL"))))

(setq dada1 (car(cdr dada)))

(setq data1 (cdr (nth 2 dada1))) ;guid

(setq data2 (cdr (nth 4 dada1))) ;status

(setq data3 (cdr (nth 5 dada1))) ;number

(setq data4 (cdr (nth 7 dada1))) ;footprintsurface

(setq data5 (cdr (nth 8 dada1))) ;country name

(setq data6 (cdr (nth 9 dada1))) ;state name

(setq data7 (cdr (nth 10 dada1)));region name

(setq data8 (cdr (nth 11 dada1)));mucipality name

(setq data9 (cdr (nth 12 dada1)));cadastral unit name

(ade_odsetfield a "Parcel" "GUID" 0 data1)

(ade_odsetfield a "Parcel" "Status" 0 data2)

(ade_odsetfield a "Parcel" "Number" 0 data3)

  	(cond ((/= data4 nil)
	(ade_odsetfield a "Parcel" "FootprintSurfaceFixed" 0 data4)
	(ade_odsetfield a "Parcel" "FootprintSurface" 0 data4)
	)							
	(T (ade_odsetfield a "Parcel" "FootprintSurface" 0 dada0))
	)

(ade_odsetfield a "Parcel" "CountryName" 0 data5)

(ade_odsetfield a "Parcel" "StateName" 0 data6)

(ade_odsetfield a "Parcel" "RegionName" 0 data7)

(ade_odsetfield a "Parcel" "MunicipalityName" 0 data8)

(ade_odsetfield a "Parcel" "CadastralUnitName" 0 data9)

(ade_odsetfield a "Parcel" "GUID" 0 data1)

(setq sslist b)

)

;(setq elist (entget a  '("ACG_PARCEL")))


)