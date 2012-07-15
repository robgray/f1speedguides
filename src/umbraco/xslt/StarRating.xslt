<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet 
  version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" xmlns:tagsLib="urn:tagsLib" xmlns:BlogLibrary="urn:BlogLibrary" xmlns:uTube.XSLT="urn:uTube.XSLT" xmlns:UCommentLibrary="urn:UCommentLibrary" xmlns:PS.XSLTsearch="urn:PS.XSLTsearch" 
  exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets tagsLib BlogLibrary uTube.XSLT UCommentLibrary PS.XSLTsearch ">


<xsl:output method="xml" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>
<xsl:param name="rating" select="/macro/rating"/>
        
<xsl:template match="/">
<!-- start writing XSLT -->
  <div>
    <xsl:choose>
      <xsl:when test="$rating = 1">
        <xsl:attribute name="class">
          rating one
        </xsl:attribute>
      </xsl:when>
      <xsl:when test="$rating = 2">
        <xsl:attribute name="class">
          rating two
        </xsl:attribute>
      </xsl:when>
      <xsl:when test="$rating = 3">
        <xsl:attribute name="class">
          rating three
        </xsl:attribute>
      </xsl:when>
      <xsl:when test="$rating = 4">
        <xsl:attribute name="class">
          rating four
        </xsl:attribute>
      </xsl:when>
      <xsl:when test="$rating = 5">
        <xsl:attribute name="class">
          rating five
        </xsl:attribute>
      </xsl:when>
      <xsl:otherwise>
        <xsl:attribute name="class">
          rating zero
        </xsl:attribute>
      </xsl:otherwise>
    </xsl:choose>       
  </div>
  
</xsl:template>

</xsl:stylesheet>