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
  <xsl:variable name="home" select="$currentPage/ancestor-or-self::Homepage" />
  <xsl:variable name="enable" select="$home/showHeaderAd" />
  
  <xsl:if test="$enable = 1">
            <div class="clear"></div>
      <div class="HeaderAd">
        <script type="text/javascript">
        google_ad_client = "ca-pub-7857304428583716";
        /* Title */
        google_ad_slot = "6053002019";
        google_ad_width = 468;
        google_ad_height = 60;
        </script>                
        <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js"></script>
      </div>
  </xsl:if>

</xsl:template>

</xsl:stylesheet>