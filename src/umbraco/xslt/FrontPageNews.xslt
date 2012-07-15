<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [
  <!ENTITY nbsp "&#x00A0;">
]>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library"
  xmlns:tagsLib="urn:tagsLib"
  xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings"
  xmlns:BlogLibrary="urn:BlogLibrary"
  exclude-result-prefixes="msxml umbraco.library tagsLib Exslt.ExsltStrings BlogLibrary">


  <xsl:output method="html" omit-xml-declaration="yes"/>

  <xsl:param name="currentPage"/>
   
  <xsl:param name="numberOfPosts" select="/macro/numberOfPosts"/>  
  <xsl:variable name="home" select="$currentPage/ancestor-or-self::Homepage" />
  <xsl:variable name="items" select="$home//umbBlogPost"/>

  <xsl:template match="/">        
    <div class="LatestNews">      
      <xsl:if test="$numberOfPosts = 0">
        <h2>All News</h2>                     
      </xsl:if>
      <xsl:if test="$numberOfPosts &gt; 0">
        <h2>Latest News</h2>                     
      </xsl:if>
<!-- The fun starts here -->    
<xsl:if test="count($items) &gt; 0">
<ul class="NewsList">
<xsl:for-each select="$items">    
<xsl:sort select="./PostDate" order="descending" />
  <xsl:if test="position() &lt;= $numberOfPosts or $numberOfPosts = 0">
  <li>
    <xsl:if test="position() = 2">
      <xsl:variable name="home" select="$currentPage/ancestor-or-self::Homepage" />
     <div id="tiprotatorcontainer">
    <div id="tiprotator">      
      <xsl:for-each select="$home//Tip">
        <div>
            <h4 class="tip"><xsl:value-of select="./@nodeName" /></h4>
            <xsl:value-of select="umbraco.library:RemoveFirstParagraphTag(./bodyText)" disable-output-escaping="yes"/>                
         </div>
      </xsl:for-each>          
    </div>
    </div>
    </xsl:if>
    <div class="Item">      
      <xsl:choose>
        <xsl:when test="./thumbnail &gt; 0">
          <xsl:variable name="mediaNode" select="umbraco.library:GetMedia(./thumbnail, 0)" />       
          <div class="fl" style="margin-right: 15px;display:none;">
          <a href="{umbraco.library:NiceUrl(@id)}">        
            <img src="/ImageGen.ashx?image={$mediaNode/umbracoFile}&amp;width=120" alt="{$mediaNode/altText}"  />
          </a>
          </div>
        </xsl:when>
        <xsl:otherwise>
          <xsl:variable name="mediaNode" select="umbraco.library:GetMedia(1688, 0)" />       
          <div class="fl" style="margin-right: 15px;display:none;">
          <a href="{umbraco.library:NiceUrl(@id)}">        
            <img src="/ImageGen.ashx?image={$mediaNode/umbracoFile}&amp;width=120" alt="{$mediaNode/altText}"  />
          </a>
          </div>
        </xsl:otherwise>
      </xsl:choose>      
          
      <div class="TextNoImage">
        <h3><a href="{umbraco.library:NiceUrl(@id)}"><xsl:value-of select="@nodeName"/></a></h3>
         <div class="entry-date">
          <abbr class="published" title="{umbraco.library:ShortDate(./PostDate)}">
             <span class="day"><xsl:value-of select="umbraco.library:FormatDateTime(./PostDate, 'dd')"/></span>
             <span class="month"><xsl:value-of select="umbraco.library:FormatDateTime(./PostDate, 'MMM')"/></span>
             <span class="year"><xsl:value-of select="umbraco.library:FormatDateTime(./PostDate, 'yyyy')"/></span>
            <span class="time"><xsl:value-of select="umbraco.library:FormatDateTime(./PostDate, 'HH:mm')"/></span>
          </abbr>
        </div>      

        <div class="Teaser"><xsl:value-of select="teaser"/></div>
      </div>
      <div class="clear"></div>
    </div>
  </li>
  </xsl:if>
</xsl:for-each>
  <xsl:if test="position() &lt;= number($numberOfPosts) and number($numberOfPosts) &gt; 0">
    <li class="MoreLink"><a href="/news">View all News &gt;</a></li>
  </xsl:if>
  </ul>
    </xsl:if>
    <xsl:if test="count($items) &lt; 2">
      <xsl:variable name="home" select="$currentPage/ancestor-or-self::Homepage" />
       <div id="tiprotatorcontainer">
        <div id="tiprotator">      
          <xsl:for-each select="$home//Tip">
            <div>
              <h4 class="tip"><xsl:value-of select="./@nodeName" /></h4>
              <xsl:value-of select="umbraco.library:RemoveFirstParagraphTag(./bodyText)" disable-output-escaping="yes"/>                
           </div>
          </xsl:for-each>          
        </div>
      </div>
    </xsl:if>
    </div>
  </xsl:template>
</xsl:stylesheet>