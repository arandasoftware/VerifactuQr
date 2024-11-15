
# Especificaciones Técnicas del Código QR para Facturas

**Versión:** 0.4.7  
**Fecha:** 17/10/2024  
**Autor:** Agencia Estatal de Administración Tributaria (AEAT)  

## Descripción

Este documento define las especificaciones técnicas para la implementación del código QR en facturas, así como la URL para el servicio de cotejo o remisión de información, en conformidad con el Real Decreto 1007/2023 y otras normativas vigentes. La aplicación del sistema **VERI*FACTU** permite verificar la validez de las facturas y facilitar la remisión de información.

## Índice

1. [Introducción](#introducción)
2. [Especificaciones del Código QR](#especificaciones-del-código-qr)
3. [Ubicación y Presentación del Código QR](#ubicación-y-presentación-del-código-qr)
4. [URL del Código QR](#url-del-código-qr)
5. [Parámetros de la URL](#parámetros-de-la-url)
6. [Ejemplos de URL válidas](#ejemplos-de-url-válidas)
7. [Ejemplos de Respuestas del Servicio](#ejemplos-de-respuestas-del-servicio)
8. [Códigos de Error de Validación](#códigos-de-error-de-validación)
9. [Normativa Legal](#normativa-legal)
10. [Anexo](#anexo)

## Introducción

El objetivo es detallar los aspectos técnicos necesarios para cumplir con los requisitos de facturación, estableciendo las condiciones para la integración del código QR en facturas emitidas por **VERI*FACTU**. Este sistema permite la validación de la autenticidad de una factura en la sede electrónica de la AEAT.

## Especificaciones del Código QR

- Tamaño: Entre 30x30 y 40x40 mm.
- Norma: ISO/IEC 18004:2015.
- Nivel de Corrección: Nivel M (medio).
- Contenido:
  - URL de cotejo o remisión de información.
  - Datos de la factura: NIF del emisor, número de serie, fecha de emisión e importe total.

## Ubicación y Presentación del Código QR

1. **Posición en la Factura:** Preferentemente en la esquina superior izquierda, con un margen en blanco alrededor de al menos 2 mm (recomendado: 6 mm).
2. **Texto Identificativo:** "QR tributario" debe aparecer encima del código QR.
3. **Frase Complementaria:** En sistemas **VERI*FACTU**, incluir "Factura verificable en la sede electrónica de la AEAT".

## URL del Código QR

La URL depende del tipo de sistema y del entorno (pruebas o producción):
- **Facturas verificables (VERI*FACTU):**  
  - Pruebas: `https://prewww2.aeat.es/wlpl/TIKE-CONT/ValidarQR?nif=XXXXXXXXY&numserie=YYYY...YYYY&fecha=DD-MM-AAAA&importe=NNNNNNNNN.DD`
  - Producción: `https://www2.agenciatributaria.gob.es/wlpl/TIKE-CONT/ValidarQR?nif=XXXXXXXXY&numserie=YYYY...YYYY&fecha=DD-MM-AAAA&importe=NNNNNNNNN.DD`
- **Facturas no verificables:**  
  - Pruebas: `https://prewww2.aeat.es/wlpl/TIKE-CONT/ValidarQRNoVerifactu?nif=XXXXXXXXX&numserie=YYYYYYYY&fecha=DD-MM-AAAA&importe=NNNNNNNN.DD`
  - Producción: `https://www2.agenciatributaria.gob.es/wlpl/TIKE-CONT/ValidarQRNoVerifactu?nif=XXXXXXXXX&numserie=YYYYYYYY&fecha=DD-MM-AAAA&importe=NNNNNNNN.DD`

## Parámetros de la URL

La URL debe incluir los siguientes parámetros:

| Parámetro  | Descripción                              | Formato            |
|------------|------------------------------------------|--------------------|
| `nif`      | NIF del emisor de la factura             | NIF (9 caracteres) |
| `numserie` | Número de serie y factura                | Texto, máx. 60     |
| `fecha`    | Fecha de emisión                         | DD-MM-AAAA         |
| `importe`  | Importe total de la factura              | Numérico, decimales |

## Ejemplos de URL válidas

- **Pruebas (Facturas Verificables):**  
  `https://prewww2.aeat.es/wlpl/TIKE-CONT/ValidarQR?nif=89890001K&numserie=12345678-G33&fecha=01-09-2024&importe=241.4`
  
- **Producción (Facturas No Verificables):**  
  `https://www2.agenciatributaria.gob.es/wlpl/TIKE-CONT/ValidarQRNoVerifactu?nif=89890001K&numserie=12345678-G33&fecha=01-09-2024&importe=241.4`

## Normativa Legal

- Artículos 20 y 21 del Real Decreto 1007/2023.
- Orden XXXXXXXXXX para la regulación de procesos de facturación electrónica.

## Anexo

Se incluyen ejemplos de códigos QR en diferentes formatos de factura y orientaciones.

Enlace documentación AEAT https://www.agenciatributaria.es/static_files/AEAT_Desarrolladores/EEDD/IVA/VERI-FACTU/DetalleEspecificacTecnCodigoQRfactura.pdf
---

Este README resume las principales especificaciones del sistema **VERI*FACTU** para el manejo de códigos QR en facturas, facilitando la validación y autenticación de la información de facturación ante la AEAT.
