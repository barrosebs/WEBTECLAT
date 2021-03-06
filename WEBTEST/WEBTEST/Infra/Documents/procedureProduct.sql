USE [WEBTECLAT]
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULT_PRODUCT_DATA]    Script Date: 23/09/2021 23:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Eduardo Barros>
-- Create date: <22/09/2021>
-- Description:	<Consulta produto por Name Product >
-- =============================================
CREATE PROCEDURE [dbo].[SP_CONSULT_PRODUCT_DATA]
(
    @PRODUCT_NAME VARCHAR(100) = NULL
)
AS
BEGIN

    SELECT
        P.idProduct,
        C.nameCategory,
        P.nameProduct,
        P.amountProduct,
        P.priceProduct
    FROM TBProduct P
    INNER JOIN TBCategory C
        ON C.idCategory = P.idCategoryProduct
    WHERE @PRODUCT_NAME IS NULL OR
          UPPER(P.nameProduct) LIKE '%' + UPPER(@PRODUCT_NAME) + '%'
    ORDER BY P.nameProduct

END