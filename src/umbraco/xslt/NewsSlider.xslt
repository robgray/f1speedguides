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
    
    <xsl:variable name="nodeIds" select="umbraco.library:Split($currentPage/slideshow,',')" />
    <div class="sliderwrap">
    <div id="news-slider">      
        <xsl:for-each select="$nodeIds/value">
          <div>            
            <xsl:variable name="slide" select="umbraco.library:GetXmlNodeById(current()/.)"/>
            <xsl:variable name="media" select="umbraco.library:GetMedia($slide/mainImage, 0)" />            
            <div class="content">
              <xsl:if test="normalize-space($media/umbracoFile)">
                <a href="{$slide/mainArticle}">
                  <img class="fl" src="/ImageGen.ashx?image={$media/umbracoFile}&amp;width=240&amp;height=173"/>
                </a>
              </xsl:if>            
              <div class="text">
                <h3><a href="{$slide/mainArticle}"><xsl:value-of select="$slide/@nodeName" /></a></h3>
                <xsl:value-of select="$slide/bodyText" disable-output-escaping="yes" />
              </div>
            </div>
          </div>
        </xsl:for-each>
    </div>
    </div>  
  </xsl:template>

</xsl:stylesheet>