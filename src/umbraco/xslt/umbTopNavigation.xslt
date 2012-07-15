<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [
    <!ENTITY nbsp "&#x00A0;">
]>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library"
  exclude-result-prefixes="msxml umbraco.library">


    <xsl:output method="html" omit-xml-declaration="yes" />

    <xsl:param name="currentPage"/>

    <!-- Input the documenttype you want here -->
    <xsl:variable name="level" select="1"/>

    <xsl:template match="/">
      <xsl:variable name="home" select="$currentPage/ancestor-or-self::Homepage" />
      <ul>
        <li><a class="navigation" href="/"><span>Home</span></a></li>              
        <xsl:for-each select="$home [@level=$level]/* [@isDoc and string(umbracoNaviHide) != '1']">
            <li>
                <xsl:if test="@id = $currentPage/@id">
                    <xsl:attribute name="class">current</xsl:attribute>
                </xsl:if>
                <a class="navigation" href="{umbraco.library:NiceUrl(@id)}">
                    <span>
                        <xsl:value-of select="@nodeName"/>
                    </span>
                </a>                
            </li>
        </xsl:for-each>
      </ul>
    </xsl:template>

</xsl:stylesheet>