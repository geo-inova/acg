
;; 
;; http://geoinova.com - INOVA informaticki inzenjering, d.o.o. 
;; Inspired by - Par Bonuscad vs 1.00 (Bruno V.) - Routine: MP2LW 
;; Transformation of MPOLYGONs to  LWPolylignes without loosing XData or Object Data 
;; 
 
 (vl-load-com)

(defun c:ACGPOL2LIN ( / js key n ent dxf_ent l_pt p11 sdata apps elst cdata )
  (vl-load-com)
  (setq js (ssget "_X" '((0 . "MPOLYGON") (-3 ("ACG_ANNOTATION")))))
  (cond
    (js
      (initget "Yes No _Yes No")
      (setq key (getkword "\nDelete Original Polygones [Yes/No]? <O>: "))
      (if (not key) (setq key "Yes"))
      (repeat (setq n (sslength js))
        (setq
          ent (ssname js (setq n (1- n)))
          dxf_ent (entget ent '("*"))
          l_pt (mapcar 'cdr (vl-remove-if-not '(lambda (x) (= (car x) 10)) dxf_ent))
          p11 (cdr (assoc 11 dxf_ent))
          l_pt (mapcar '(lambda (x) (list (+ (car x) (car p11)) (+ (cadr x) (cadr p11)) (caddr x))) (cdr l_pt))
        )
        (entmake
          (append
            (list
              '(0 . "LWPOLYLINE")
              '(100 . "AcDbEntity")
              (assoc 67 dxf_ent)
              (assoc 410 dxf_ent)
              (assoc 8 dxf_ent)
              (if (assoc 62 dxf_ent) (assoc 62 dxf_ent) '(62 . 256))
              (if (assoc 6 dxf_ent) (assoc 6 dxf_ent) '(6 . "BYLAYER"))
              (if (assoc 370 dxf_ent) (assoc 370 dxf_ent) '(370 . -1))
              '(100 . "AcDbPolyline")
              (cons 90 (1- (length l_pt)))
              '(70 . 1)
              '(43 . 0.0)
              (cons 38 (cadddr (assoc 10 dxf_ent)))
              '(39 . 0.0)
            )
            (apply 'append (mapcar '(lambda (x) (list (cons 10 x) (cons 40 0.0) (cons 41 0.0) (cons 42 0.0))) l_pt))
            (list (assoc 210 dxf_ent))
          )
        )
        (if copy_data (COPY_DATA ent (entlast) "All"))
        (setq
          sdata (cdr (assoc -3 dxf_ent))
          apps (mapcar 'car sdata)
          elst (entget (entlast) '("*"))
          cdata (cdr (assoc -3 elst))
          elst  (vl-remove (assoc -3 elst) elst)
        )
        (entmod
          (append elst
            (list
              (cons -3
                (append
                  (vl-remove-if
                    (function
                      (lambda (x)
                        (member (car x) apps)
                      )
                    )
                    cdata
                  )
                  sdata
                )
              )
            )
          )
        )
        (if (eq key "Yes") (entdel ent))
      )
    )
  )
  (prin1)
) 

