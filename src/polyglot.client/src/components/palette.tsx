export default function Palette({theme, colors, isLightTheme}: { theme: string, colors: string[], isLightTheme: boolean }) {
  return (
    <div className="flex justify-between">
      <div className="me-2 text-foreground">
        {theme}
      </div>
      <div className="flex">
        {colors.map(color =>
          <div key={color} className={`w-6 h-6 rounded-full border-1 ${isLightTheme ? 'border-white' : 'border-black'} `} style={{backgroundColor: color}}></div>
        )}
      </div>
    </div>
  )
}