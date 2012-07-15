<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets"
  exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets ">


<xsl:output method="xml" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>

  <xsl:template match="/">    
    <xsl:if test="string-length($currentPage/slideshow) &gt; 0">
      <xsl:variable name="nodeIds" select="umbraco.library:Split($currentPage/slideshow,',')" />
      <div class="FeatureCarousel">
        <div id="Features">
          <xsl:for-each select="$nodeIds/value">
            <xsl:variable name="slide" select="umbraco.library:GetXmlNodeById(current()/.)"/>
            <xsl:variable name="media" select="umbraco.library:GetMedia($slide/mainImage, 0)" />        
            <div>          
              <xsl:choose>
                <xsl:when test="position() = 1">
                  <xsl:attribute name="class">Item First clearfix</xsl:attribute>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:attribute name="class">Item clearfix</xsl:attribute>
                </xsl:otherwise>
              </xsl:choose>          
              <xsl:attribute name="style">background: url(/ImageGen.ashx?image=<xsl:value-of select="$media/umbracoFile" />&amp;height=240) no-repeat 0 0 transparent;</xsl:attribute>
              <div class="Main">
                <h2><a href="{umbraco.library:NiceUrl($slide/mainArticle)}"><xsl:attribute name="style">color: #<xsl:value-of select="$slide/headingColor" /></xsl:attribute><xsl:value-of select="$slide/@nodeName" /></a></h2>
                <span>
                  <xsl:attribute name="style">color: #<xsl:value-of select="$slide/textColor" /></xsl:attribute>
                  <xsl:value-of select="$slide/bodyText" disable-output-escaping="yes" />
                </span>
              </div>                     
            </div>    
          </xsl:for-each>  
        </div>                
      </div>     
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>