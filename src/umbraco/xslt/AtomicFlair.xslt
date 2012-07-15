<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:af1="urn:atomicf1.extensions"
  xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" xmlns:tagsLib="urn:tagsLib" xmlns:BlogLibrary="urn:BlogLibrary" xmlns:uTube.XSLT="urn:uTube.XSLT" xmlns:atomicf1.extensions="urn:atomicf1.extensions" xmlns:UCommentLibrary="urn:UCommentLibrary" xmlns:PS.XSLTsearch="urn:PS.XSLTsearch"
  exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets tagsLib BlogLibrary uTube.XSLT atomicf1.extensions UCommentLibrary PS.XSLTsearch af1">


<xsl:output method="html" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>
<xsl:template match="/">  
  <xsl:variable name="atomicid" select="af1:GetDriver($currentPage/driverId)//driver/atomicid" />
  <div>    
    <iframe width="204" scrolling="no" height="60" frameborder="0" src="http://atomicflair.robertgray.net.au/user/id/{$atomicid}"></iframe>  
  </div>
</xsl:template>
</xsl:stylesheet>