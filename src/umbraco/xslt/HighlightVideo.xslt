<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet 
  version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" xmlns:tagsLib="urn:tagsLib" xmlns:BlogLibrary="urn:BlogLibrary" xmlns:uTube.XSLT="urn:uTube.XSLT" xmlns:atomicf1.extensions="urn:atomicf1.extensions" xmlns:PS.XSLTsearch="urn:PS.XSLTsearch" xmlns:UCommentLibrary="urn:UCommentLibrary" 
  exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets tagsLib BlogLibrary uTube.XSLT atomicf1.extensions PS.XSLTsearch UCommentLibrary ">


<xsl:output method="html" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>

<xsl:template match="/">

  <xsl:if test="count($currentPage/Video) &gt; 0">
      <h2>Race footage</h2>         
      <xsl:for-each select="$currentPage/Video">
        <xsl:sort select="@sortOrder" />
        <xsl:if test="position() = 1">  
          <div class="grid_7 alpha">          
            <iframe width="560" height="349" src="http://www.youtube.com/embed/{./youTubeVideoId}" frameborder="0" allowfullscreen="1"></iframe>
          </div>      
        </xsl:if>        
      </xsl:for-each>
  </xsl:if>
</xsl:template>

</xsl:stylesheet>